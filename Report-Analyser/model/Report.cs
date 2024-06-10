namespace Report_Analyser.model {
    internal class Report {
        public string id { get; }
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public string ExceptionClass { get; set; }
        public string ExceptionMessage { get; set; }
        public string Publisher { get; set; }
        public string PublisherEmail { get; set; }
        public Client Client { get; }
        public User User { get; }
        public CallStack CallStack { get; }

        public Report() {
            this.Client = new Client();
            this.User = new User();
            this.CallStack = new CallStack();
        }

        public Report(string id) {
            this.id = id;
            this.Client = new Client();
            this.User = new User();
            this.CallStack = new CallStack();
        }
    }

    internal record Client {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }
    }

    internal record User {
        public string Name { get; set; }
        public string Email { get; set; }

    }

    internal class CallStack {
        public List<String> lstCallStack { get; }

        public CallStack() {
            lstCallStack = new List<String>();
        }

        public void Add(string stack) {
            lstCallStack.Add(stack);
        }

    }
}


