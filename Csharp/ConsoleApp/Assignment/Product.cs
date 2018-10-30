using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    class Product
    {
        
        // member or member field
        private string name;
        private float price;
        private int qty;
        private string color;
        private readonly string kindofproduct;
                              
        // Construct
        
        public Product(string pname, float pprice, int pqty, string pcolor, char pkindofproduct = 'C')
        {
            name = pname;
            price = pprice;
            qty = pqty;
            color = pcolor;
            kindofproduct = pkindofproduct== 'C' ? "Car" : "MotoCycle";
        
        }

        // Property
        // 정의한 member type에 대해 값을 input, output할수 있는 methoad
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public int Qty
        {
            get { return this.qty; }
            set { this.qty = value; }
             
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        // read only property
        public string KindofProduct
        {  get { return this.kindofproduct; }

        }

        public enum Status : int
        {
            InStock,
            OutofStock
        }

        public string GetStatusData()
        {
            string data1 = "";

            if (this.qty > 0)

                data1 = "InStock";
            else 
                data1 = "OutOfStock";

            return this.name + ":" + data1;
            
        }

        public string GetCustomerData()
        {
            string data = string.Format("Name: {0} Price: {1} Qty: {2}, Color: {3}, Kind: {4})",
                        this.name, this.price, this.qty, this.color, this.kindofproduct);
            return data;
        }

        public float TotalPrice()
        {
            float totalprice = 0;
            totalprice = this.price * 1.5f;
            return totalprice;
        }
        
        public string TotalPrice(string mname, float mprice)
        {
            return string.Format("returning name and price: {0},{1}", mname, mprice);
        }

        public string TotalPrice(string mname, float mprice, DateTime dt)
        {
            //DateTime dt1 = new DateTime();
            return string.Format("returning name and price and date: {0},{1},{2}", mname, mprice, dt);
        }

        
    }
} 
