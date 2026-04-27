using System.Security.Principal;
 using Bankcom.Models;
            using Microsoft.EntityFrameworkCore;


namespace Bankcom
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
    {
        
                using BankDbContext dbContext = new();
                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("National Bankcom Management");
                    Console.WriteLine("===================================");
                    Console.WriteLine("1) Add a new Customer");
                    Console.WriteLine("2) Open a new Account for a Customer");
                    Console.WriteLine("3) Update Account Status (Active / Closed)");
                    Console.WriteLine("4) Remove an Account from a Customer");
                    Console.WriteLine("5) List all Customers (with accounts)");
                    Console.WriteLine("0) Exit");
                    Console.Write("\nEnter choice: ");
                    string? choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1": AddCustomer(dbContext); break;
                        case "2": OpenAccount(dbContext); break;
                        case "3": UpdateAccountStatus(dbContext); break;
                        case "4": RemoveAccount(dbContext); break;
                        case "5": ListCustomers(dbContext); break;
                        case "0": exit = true; break;
                        default:
                            Console.WriteLine("\n  [!] Unknown option.");
                            Pause();
                            break;
                    }


                }
                static void AddCustomer(BankDbContext dbContext)
                {
                    Console.WriteLine("Add a new Customer");
                    Console.Write("Enter Customer Name: ");
                    var customer = new Customer();
                    string? name = Console.ReadLine();
                    customer.FullName = name ?? string.Empty;
                    Console.Write("Enter Email: ");
                    string? email = Console.ReadLine();
                    customer.Email = email ?? string.Empty;
                    Console.Write("Enter Phone Number: ");
                    string? phoneNumber = Console.ReadLine();
                    customer.PhoneNumber = phoneNumber ?? string.Empty;
                    Console.Write("Enter Your Address): ");
                    string? address = Console.ReadLine();
                    customer.Address = address ?? string.Empty;
                    Console.WriteLine("Select Customer Type:");
                    Console.WriteLine("1) Individual");
                    Console.WriteLine("2) Business");
                    Console.Write("Choice: ");
                    string? typeChoice = Console.ReadLine();
                    if (typeChoice == "1")
                    {
                        customer.CustomerType = CustomerType.individuals;
                    }
                    else if (typeChoice == "2")
                    {
                        customer.CustomerType = CustomerType.Businesses;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Defaulting to Individual.");
                        customer.CustomerType = CustomerType.individuals;
                    }

                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();
                    Console.WriteLine("Customer Created successfully!"); Console.WriteLine("press any key to return to the menu...");
                    Console.ReadKey();

                }
                static void OpenAccount(BankDbContext dbContext)
                {
                    Console.WriteLine("----Open new Account---");
                    var account = new Account();
                    Console.Write("Account Number: ");
                    string? accountNumber = Console.ReadLine();
                    if (!int.TryParse(accountNumber, out int parsedAccountNumber))
                    {
                        Console.WriteLine("Invalid account number. Aborting.");
                        Console.WriteLine("press any key to return to the menu...");
                        Console.ReadKey();
                        return;
                    }
                    account.AccountNumber = parsedAccountNumber;
                    Console.WriteLine("Account Type:");
                    Console.WriteLine("1) Savings");
                    Console.WriteLine("2) Current");
                    Console.WriteLine("3) Business");
                    Console.Write("Choice: ");
                    string? typeChoice = Console.ReadLine();
                    if (typeChoice == "1")
                    {
                        account.Type = AccountType.Savings;
                    }
                    else if (typeChoice == "2")
                    {
                        account.Type = AccountType.Current;
                    }
                    else if (typeChoice == "3")
                    {
                        account.Type = AccountType.Business;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Defaulting to Savings.");
                        account.Type = AccountType.Savings;
                    }
                    Console.Write("Branch Code: ");
                    string? BranchCode = Console.ReadLine();
                    account.Branch = account.Branch ?? new Branch();
                    account.Branch.BranchCode = BranchCode ?? string.Empty;
                    int customerId;
                    while (true)
                    {
                        Console.Write("Customer Id : ");
                        string? customerIdInput = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(customerIdInput) && int.TryParse(customerIdInput, out customerId))
                            break;

                        Console.WriteLine("Invalid customer id. Try again.");
                    }
                    Console.WriteLine("Ownership Role:");
                    Console.WriteLine("1) Primary");
                    Console.WriteLine("2) CoHolder");
                    Console.Write("Choice: ");
                    string? roleChoice = Console.ReadLine();
                    switch (roleChoice)
                    {
                        case "1":
                            Console.WriteLine($"Validating branch '{BranchCode}' and customer #{customerId}");
                            Console.WriteLine($"Account '{parsedAccountNumber}' created and linked to customer #{customerId} as Primary owner.");
                            break;
                        case "2":
                            Console.WriteLine($"Validating branch '{BranchCode}' and customer #{customerId}");
                            Console.WriteLine($"Account '{parsedAccountNumber}' created and linked to customer #{customerId} as CoHolder.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Defaulting to Primary.");
                            break;
                    }

                    var customerAccount = new CustomerAccount
                    {
                        OwnerShipDate = DateTime.Now,
                        OwnershipType = roleChoice == "2" ? OwnershipType.CoHolder : OwnershipType.Primary,
                        AccountStatus = AccountStatus.Active,
                        CustomerId = customerId,
                        AccountNumber = parsedAccountNumber



                    };


                    Console.WriteLine("press any key to return to the menu...");
                    Console.ReadKey();
                }
                static void UpdateAccountStatus(BankDbContext dbContext)
                {
                    Console.WriteLine("----Update Account Status---");

                    Console.Write("Account Number: ");
                    string? accountNumber = Console.ReadLine();
                    Console.Write("Customer Id: ");
                    string? customerId = Console.ReadLine();
                    Console.WriteLine("New Status:");
                    Console.WriteLine("1) Active");
                    Console.WriteLine("2) Closed");
                    Console.Write("Choice: ");
                    string? statusChoice = Console.ReadLine();
                    switch (statusChoice)
                    {
                        case "1":
                            Console.WriteLine($"Status Updated to Active");
                            break;
                        case "2":
                            Console.WriteLine($"Status Updated to Closed");
                            break;
                        default:
                            Console.WriteLine("Invalid status choice.");
                            break;
                    }
                    dbContext.SaveChanges();
                    Console.WriteLine("press any key to return to the menu...");
                    Console.ReadKey();

                }
                static void RemoveAccount(BankDbContext dbContext)
                {
                    Console.WriteLine("---Remove Account From Customer---");
                    Console.WriteLine("Account Number: ");
                    string? accountNumber = Console.ReadLine();
                    Console.WriteLine("Customer Id: ");
                    string? customerId = Console.ReadLine();
                    var customerAccount = dbContext.CustomerAccounts
                                .FirstOrDefault(ca => ca.AccountNumber == int.Parse(accountNumber) && ca.CustomerId == int.Parse(customerId));
                    if (customerAccount != null)
                    {
                        dbContext.CustomerAccounts.Remove(customerAccount);
                        dbContext.SaveChanges();
                        Console.WriteLine("Account removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    Console.WriteLine("press any key to return to the menu...");
                    Console.ReadKey();
                }
                static void ListCustomers(BankDbContext dbContext)
                {
                    Console.WriteLine("---List of Customers---");
                    var customers = dbContext.Customers
                            .Include(c => c.CustomerAccounts)
                                .ThenInclude(ca => ca.Account)
                                    .ThenInclude(a => a.Branch)
                            .OrderBy(c => c.CustomerId)
                            .ToList();

                    foreach (var c in customers)
                    {
                        Console.WriteLine($"  #{c.CustomerId} {c.FullName} ({c.CustomerType})");
                        if (!c.CustomerAccounts.Any())
                        {
                            Console.WriteLine("       (no accounts)");
                        }
                        else
                        {
                            foreach (var ca in c.CustomerAccounts)
                            {
                                var a = ca.Account;
                                Console.WriteLine(
                                    $"       {a.AccountNumber,-12} {a.Type,-8} Balance: {a.CurrentBalance,12:F2}  " +
                                    $"{ca.OwnershipType,-10} {ca.AccountStatus,-7} @ {a.Branch.BranchName}");
                            }

                        }
                    }




                    Pause();

                }

                static void Pause()
                {
                    Console.Write("\nPress any key to return to the menu...");
                    Console.ReadKey(intercept: true);
                }

            }
        }
    }


}
