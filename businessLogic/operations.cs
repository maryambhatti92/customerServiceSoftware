using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessEntityLayer;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace businessLogic
{
    //business logic is business access layer, accesses data from db
    public class operations
    {
        public dbConnection db = new dbConnection();
        public informations info = new informations();

        //here we include queries and dboperations

        public int insertEmployee(informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tbl_register(id,name, gender,dob,address, education) "+
            "values(1,'" + info.name + "','" + info.gender + "','" + info.dob + "','" + info.address + "','" + info.education + "')";

            return db.ExeNonQuery(cmd);
          
            //throw new NotImplementedException();
        }

        public DataTable login(informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_register where name = '"+info.name+"' and password = '"+info.password+"'";
           
          
            return  db.ExeReader(cmd);
        }

        public DataTable viewEmp(informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_register";


            return db.ExeReader(cmd);
        }

        public DataTable mainTableDataLoadData(informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ref_num as 'Case', priority as 'Prioritization', st.status as 'Status',cname as 'Customer', issue as 'Service Reason', date_added as 'Date' ,c.id as 'ID',cr.customer_file as 'File'" +
                "from tbl_customer_request cr left join tbl_customer c on c.id=cr.customer_id left join tbl_status st on st.id=cr.status";


            return db.ExeReader(cmd);
        }

        public DataTable fillBasicData(informations info)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_customer c left join tbl_customer_request cr on c.id=cr.customer_id"+
                " left join tbl_zipcodes z on z.id=c.zipcode_id left join tbl_country cnt on cnt.id=c.country_id where c.id= '" + info.customerID + "';";


            return db.ExeReader(cmd);
            
        }

        public DataTable fillBasicDataContactPerson(informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_contact_person where customer_id= '" + info.customerID + "';";


            return db.ExeReader(cmd);
        }

        public int updateBasicData(informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update tbl_customer_request set issue = '" + info.issue + "', error_description = '" + info.error + "'" +
            " where customer_id = '" + info.customerID + "'";

            db.ExeNonQuery(cmd);


            //check if zipcode exist add zipcode id to the query below, check country if exist in tbl_country then add id otherwiae insert and add id to the query below

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update tbl_customer set cname = '" + info.cname + "', address = '" + info.caddress + "', company = '" + info.company + "', street = '" + info.street + "'" +
            " where id = '" + info.customerID + "'";

            return db.ExeNonQuery(cmd1);

        }

        public int updateData(informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update tbl_customer_request set worker = '" + info.cname + "'" +
            " where customer_id = '" + info.customerID + "'";

            return db.ExeNonQuery(cmd);          

        }
    }



}
