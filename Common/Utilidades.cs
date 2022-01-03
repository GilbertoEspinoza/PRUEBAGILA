using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Common
{
    public static class Utilidades
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static SelectList AddFirstItem(SelectList list)
        {
            List<SelectListItem> _list = list.ToList();

            if (_list.Count > 0)
                _list.Insert(0, new SelectListItem() { Value = "0", Text = "- SELECCIONAR -" });
            else
                _list.Insert(0, new SelectListItem() { Value = "0", Text = "- SIN INFORMACIÓN -" });

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
        }

        public static SelectList AddFirstItemV(SelectList list)
        {
            List<SelectListItem> _list = list.ToList();

            if (_list.Count > 0)
                _list.Insert(0, new SelectListItem() { Value = "", Text = "- SELECCIONAR -" });
            else
                _list.Insert(0, new SelectListItem() { Value = "", Text = "- SIN INFORMACIÓN -" });

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
        }

        public static SelectList AddFirstItem(SelectList list,int id)
        {
            List<SelectListItem> _list = list.ToList();

            if (_list.Count > 0)
                _list.Insert(0, new SelectListItem() { Value = "0", Text = "- SELECCIONAR -" });
            else
                _list.Insert(0, new SelectListItem() { Value = "0", Text = "- SIN INFORMACIÓN -" });

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text",id);
        }

        public static SelectList AddFirstItems(SelectList list)
        {
            List<SelectListItem> _list = list.ToList();

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
        }

        public static SelectList AddFirstItems(SelectList list,int id)
        {
            List<SelectListItem> _list = list.ToList();

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text",id);
        }

        public static SelectList DropDownTipoUsuario(int id)
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "", Text = "- SELECCIONAR -", Selected = true });
            _list.Insert(1, new SelectListItem() { Value = "1", Text = "INTERNO" });
            _list.Insert(2, new SelectListItem() { Value = "2", Text = "EXTERNO" });

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text", id);
        }

        public static SelectList DropDownTipoSexo(int id)
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "", Text = "- SELECCIONE UN SEXO -", Selected = true });
            _list.Insert(1, new SelectListItem() { Value = "1", Text = "FEMENINO" });
            _list.Insert(2, new SelectListItem() { Value = "2", Text = "MASCULINO" });

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text", id);
        }

        public static SelectList DropDownTipoContrato(int id)
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "", Text = "- SELECCIONAR -", Selected = true });
            _list.Insert(1, new SelectListItem() { Value = "1", Text = "PRACTICANTE" });
            _list.Insert(2, new SelectListItem() { Value = "2", Text = "TEMPORAL" });
            _list.Insert(3, new SelectListItem() { Value = "3", Text = "INDEFINIDO" });
            _list.Insert(4, new SelectListItem() { Value = "4", Text = "OBRA/EVENTUAL" });

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text", id);
        }

        public static SelectList DropDownTipoSuministro()
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "2", Text = "AUTORIZADO" });
            _list.Insert(1, new SelectListItem() { Value = "3", Text = "RECHAZADO" });

            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
        }

        public static object ToDBNull(object value)
        {
            if (null != value)
                return value.ToString().ToLower().Trim();
            return DBNull.Value;
        }

        public static object ToDBNull2(object value)
        {
            if (null != value)
                return value.ToString().Trim();
            return DBNull.Value;
        }

        public static object ToDBNullInt(object value)
        {
            if (null != value)
                return value;
            return 0;
        }

        public static object ToDBNullDate(object value)
        {
            if (null != value)
            {
                DateTime dt = Convert.ToDateTime(value);
                if(dt.Year!= 0001 && dt.Year != 1900)
                    return value;
                else
                    return DBNull.Value;
            }                
            
            return DBNull.Value;
        }

        public static string Cortar(this string value)
        {
            string nombre = "";
            nombre = value.Substring(0,value.IndexOf(' '));
            return nombre;
        }

    }
}
