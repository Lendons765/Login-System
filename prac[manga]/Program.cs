using System;
class Program{
    static void Main(){
        string[,] users = {{"admin", "admin123"} , {"manager","manager123"}};
        string[,] products = {
            {"Apples", "Bananas", "Milk", "Bread", "Eggs" },
            {"10", "15", "20", "30", "20"}
        };
        int attempt = 0;
        bool auth = false;

        while(attempt < 3 && !auth){
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            for(int i = 0; i < users.GetLength(0);i++){
                if(username == users[i ,0] && password == users[i, 1]){
                    auth=true;
                    Console.WriteLine("Login Sucessful! Welcome to the inventory Management System. ");
                    
                    while(true){
                        Console.WriteLine("\nSelect an option from the menu: ");
                        Console.WriteLine("1.View inventory ");
                        Console.WriteLine("2.Update stock ");
                        Console.WriteLine("3. Calculate units ");
                        Console.WriteLine("4. exit: ");
                        Console.WriteLine("Enter  Choice ");
                        string choice = Console.ReadLine();
                        
                        switch(choice){
                            case "1":
                                Console.WriteLine("Current Inventory: ");
                                for(int k = 0; k < 5; k++){
                                    Console.WriteLine(products[0 , k] + ": " + products[1, k] + " units");
                                    /*for(int l = 0; l < 5; l++){
                                        Console.WriteLine(products[0 , k] + ": " + products[1, l] + " units");
                                    }*/
                                   
                                }
                                break;
                            
                            case "2":
                                Console.WriteLine("Enter Product Name: ");
                                string Pname = Console.ReadLine();
                                Console.WriteLine("Enter Quantity to add : ");
                                string qadd = Console.ReadLine();
                                
                                int pFound = 0;
                                bool pfinal = false;
                                for (int j = 0; j < products.GetLength(1); j++){
                                    if (Pname == products[0, j]){
                                        int oldQuantity = Convert.ToInt32(products[1, j]); 
                                        int addQuantity = Convert.ToInt32(qadd);
                                        
                                        int newQuantity = oldQuantity + addQuantity;
                                        products[0, j] = newQuantity.ToString();
                                        
                                        Console.WriteLine("Updated Inventory:" + Pname +  " now has " + products[0,j] + " units.");
                                        pfinal = true;
                                    }
  
                                }
                                break;
                            case "3":
                                int totalproducts = 0;
                                for (int l = 0; l < products.GetLength(1); l++){
                                    int integerProducts = Convert.ToInt32(products[1, l]);
                                     totalproducts += integerProducts;
                                }
                                Console.WriteLine($"Total products in stock: {totalproducts} units.");
                                break;
                                
                            
                            case "4":
                                Console.WriteLine("Logout Sucessful. Exiting System");
                                auth = true;
                                break;
                            default:
                                Console.WriteLine("Invalid Option");
                            break;    
                        } 
                    }
                    
                    Console.WriteLine();
                   
                }
            }
            if(!auth){
                attempt++;
                Console.WriteLine("Login failed! attempt "+ attempt +" of 3");
            }
            
            if(attempt == 3){
                Console.WriteLine("Too Many failed attempts. Exiting Program.");
                return;
            }
            
            


        }
    }
}
    
