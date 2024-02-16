namespace ContactBook
{
    public class ContactDatabase
    {
        private static List<string> FirstNames = ["John", "Jane", "Robert", "Sarah", "Alice", "Trudy", "Charlie", "Chet"];
        private static List<string> LastNames = ["Smith", "Doe", "Carpenter", "Buxley", "Twist", "Dawson", "Biden", "Bigsley"];
        private static List<string> MiddleNames = ["Taylor", "Jordan", "Morgan", "Riley", "Avery", "Casy", "Quinn", "Cameron"];
        private readonly Dictionary<int, Contact> contacts = new Dictionary<int, Contact>();
        
        public ContactDatabase()
        {
            Random random = new Random();
            foreach (int id in Enumerable.Range(1, 50))
            {
                var contact = new Contact
                {
                    Id = id,
                    FirstName = FirstNames[random.Next(0, FirstNames.Count)],
                    LastName = LastNames[random.Next(0, LastNames.Count)],
                    MiddleName = MiddleNames[random.Next(0, MiddleNames.Count)]
                };
                contact.Email = $"{contact.FirstName}.{contact.MiddleName[0]}.{contact.LastName}@email.com".ToLower();

                this.contacts.Add(id, contact);
            }
        }

        public List<Contact> GetContacts()
        {
            return contacts.Values.ToList();
        }

        public Contact? GetContact(int id)
        {
            try
            {
                var contact = contacts[id];

                return contact;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
