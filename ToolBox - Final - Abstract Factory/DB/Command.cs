using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Command
    {
        #region Properties
        public Dictionary<string, object> Parameters { get; private set; } //Paremeters => Stocke le nom et la valeur, la valeur étant indéfinie, nous mettons le type object
        public string CommandText { get; private set; } //CommandText => String représentant notre future requête SQL
        public bool IsStoredProcedure { get; private set; } //CommandType => si true alors commandText est une procedure stockée, si false alors commandText est une requête de type texte
        #endregion

        #region Constructors
        public Command(string commandText):this(commandText,false)
        {

        }

        public Command(string commandText, bool isStoredProcedure)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                throw new Exception("La requête est invalide");
            }
            CommandText = commandText;
            IsStoredProcedure = isStoredProcedure;
            Parameters = new Dictionary<string, object>();
        }
        #endregion

        #region Methods
        public void AddParameter(string name, object value)
        {
            Parameters.Add(name, (value == null)?DBNull.Value:value );
        }

        public void SetParameters<T>(object o)
            where T: Attribute// /!\ si procedure stockée, elle doit prendre le même nombre d'arguments que l'item a de propriétés
        {
            List<PropertyInfo> properties = o.GetType().GetProperties().ToList<PropertyInfo>() ;
            PropertyInfo[] removables = new object().GetType().GetProperties();
            foreach(PropertyInfo rem in removables)
            {
                properties.Remove(rem);
            }
            foreach(PropertyInfo p in properties)
            {
                if (!p.IsDefined(typeof(T))) {
                    AddParameter(($"@{p.Name.ToLower()}"), p.GetValue(o));
                        }
                //else Console.WriteLine(attribute, p.GetCustomAttribute(attribute));

            }
        }
        public void SetParameters(object o)
        {
            List<PropertyInfo> properties = o.GetType().GetProperties().ToList<PropertyInfo>();
            PropertyInfo[] removables = new object().GetType().GetProperties();
            foreach (PropertyInfo rem in removables)
            {
                properties.Remove(rem);
            }
            foreach (PropertyInfo p in properties)
            {
                    AddParameter(($"@{p.Name.ToLower()}"), p.GetValue(o));
                //else Console.WriteLine(attribute, p.GetCustomAttribute(attribute));

            }
        }

        #endregion
    }
}
