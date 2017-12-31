using Concert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Concert.Controllers
{
    public class SchApiController : ApiController
    {
        // GET api/<controller>
        public List<CalendarModel> Get()
        {
            List<CalendarModel> lista = new List<CalendarModel>();
            DataAcces.xsData.ScheduleDataTable table = new DataAcces.xsData.ScheduleDataTable();
            DataAcces.xsDataTableAdapters.ScheduleTableAdapter adapter = new DataAcces.xsDataTableAdapters.ScheduleTableAdapter();
            adapter.Fill(table);
            foreach(DataAcces.xsData.ScheduleRow row in table)
            {
                CalendarModel cal = new CalendarModel();
                cal.Id = row.IdPgr.ToString();
                cal.Title = row.NombreEvento;
                cal.AllDay = false;
                cal.Start = row.Desde;
                cal.End = row.Hasta;                
                lista.Add(cal);
            }
            return lista;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}