using _02_Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Console
{
    public class ProgramUI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaims();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                //1.See all claims
                //2.Take care of next claim
                //3.Enter a new claim
                Console.Clear();
                Console.WriteLine("Enter the option number you'd like to select: \n" +
                    "1) See all claims \n" +
                    "2) Take care of next claim \n" +
                    "3) Enter a new claim \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response between 1 and 4. \n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void EnterNewClaim()
        {
            KClaim claim = new KClaim();
            //Get user input
            Console.WriteLine("Please enter the claim ID: ");
            string claimID = Console.ReadLine();
            claim.ClaimID = claimID;
            Console.WriteLine("Select a claim type : \n" +
                "1) Car \n" +
                "2) Home \n" +
                "3) Theft");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    claim.TypeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    claim.TypeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    claim.TypeOfClaim = ClaimType.Theft;
                    break;
            }
            Console.WriteLine("Please enter the description of the claim:");
            string claimDescription = Console.ReadLine();
            claim.ClaimDesription = claimDescription;
            Console.WriteLine("Please enter the claim amount: ");
            claim.ClaimAmount = double.Parse(Console.ReadLine());

            DateTime incidentDate;
            Console.WriteLine("Enter date of incident in format MM/DD/YYYY: ");
            //accepts date in MM/dd/yyyy format
            incidentDate = DateTime.Parse(Console.ReadLine());
            claim.DateOfIncident = incidentDate;
            DateTime claimDate;
            Console.WriteLine("Enter date of claim in format MM/DD/YYYY: ");
            //accepts date in MM/dd/yyyy format
            
            claimDate = DateTime.Parse(Console.ReadLine());
            claim.DateOfClaim = claimDate;
            bool claimIsValid = true;

            //deal with isValid
            //System.TimeSpan diff = secondDate.Subtract(firstDate);
            //System.TimeSpan diff1 = secondDate - firstDate;
            /*TimeSpan*/
            double difference = (claimDate - incidentDate).TotalDays;
            
            if (difference > 30)
            {
                claimIsValid = false;
            }
            claim.IsValid = claimIsValid;

            _claimRepo.AddClaimToDirectory(claim);
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            //get claims from db
            List<KClaim> listOfClaims = _claimRepo.GetClaims();
            //display each item property values
            foreach (KClaim claim in listOfClaims)
            {
                DisplaySimple(claim);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void TakeCareOfNextClaim()
        {
            //Display next claim
            List<KClaim> listOfClaims = _claimRepo.GetClaims();
            DisplaySimple(listOfClaims.First());
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string userResponse = Console.ReadLine();
            if (userResponse == "y")
            {
                listOfClaims.RemoveAt(0);
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
            }
            else if (userResponse == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("You've entered an invalid key, please try again");
                Console.ReadKey();
                return;
            }

        }
        private void DisplaySimple(KClaim claim)
        {
            Console.WriteLine
               ($"Claim ID: {claim.ClaimID} \n" +
                $"Claim Type: {claim.TypeOfClaim} \n" +
                $"Claim Description: {claim.ClaimDesription} \n" +
                $"Claim Amount: {claim.ClaimAmount} \n" +
                $"Claim Incident Date: {claim.DateOfIncident} \n" +
                $"Claim Claim Date: {claim.DateOfClaim} \n" +
                $"Claim Is Valid: {claim.IsValid} \n" +
                $"------------------------------------------");
        }
        private void SeedClaims()
        {
            DateTime indicentDateOne = new DateTime(2018, 04, 25);
            DateTime indicentDateTwo = new DateTime(2018, 04, 11);
            DateTime indicentDateThree = new DateTime(2018, 04, 27);
            DateTime claimDateOne = new DateTime(2018, 04, 27);
            DateTime claimDateTwo = new DateTime(2018, 04, 12);
            DateTime claimDateThree = new DateTime(2018, 06, 01);

            var claimOne = new KClaim("1", ClaimType.Car, "Car accident on 465.", 400.00, indicentDateOne, claimDateOne, true);
            var claimTwo = new KClaim("2", ClaimType.Home, "House fire in kitchen.", 4000.00, indicentDateTwo, claimDateTwo, true);
            var claimThree = new KClaim("3", ClaimType.Theft, "Stolen pancakes.", 4.00, indicentDateThree, claimDateThree, false);
            _claimRepo.AddClaimToDirectory(claimOne);
            _claimRepo.AddClaimToDirectory(claimTwo);
            _claimRepo.AddClaimToDirectory(claimThree);
        }

    }
}
