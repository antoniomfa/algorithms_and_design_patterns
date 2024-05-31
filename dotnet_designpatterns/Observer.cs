using System;

namespace dotnet_designpatterns
{
    /* The Observer design pattern allows us to establish a notification mechanism between objects. It enables multiple objects to subscribe to another object and get 
     * notified when an event occurs to this observed object. So, on one hand, we have a Provider (sometimes called a Subject or a Publisher) which is the observed object. 
     * On the other hand, there are one or more Observers, which are objects subscribing to the Provider. An Observer can subscribe to a Provider and get notified whenever a 
     * predefined condition happens. This predefined condition is usually an event or a state change. */
    public class Observer
    {
        //static void Main(string[] args)
        //{
        //    var observer1 = new HRSpecialist("Bill");
        //    var observer2 = new HRSpecialist("John");
        //    var provider = new ApplicationsHandler();

        //    observer1.Subscribe(provider);
        //    observer2.Subscribe(provider);

        //    provider.AddApplication(new(1, "Jesus"));
        //    provider.AddApplication(new(2, "Dave"));

        //    observer1.ListApplications();
        //    observer2.ListApplications();

        //    observer1.Unsubscribe();

        //    Console.WriteLine();
        //    Console.WriteLine($"{observer1.Name} unsubscribed");
        //    Console.WriteLine();

        //    provider.AddApplication(new(3, "Sofia"));

        //    observer1.ListApplications();
        //    observer2.ListApplications();

        //    Console.WriteLine();

        //    provider.CloseApplications();
        //}
    }

    public class Application
    {
        public int JobId { get; set; }
        public string ApplicantName { get; set; }

        public Application(int jobId, string applicantName)
        {
            JobId = jobId;
            ApplicantName = applicantName;
        }
    }

    public class HRSpecialist : IObserver<Application>
    {
        private IDisposable _cancellation;
        public string Name { get; set; }
        public List<Application> Applications { get; set; }

        public HRSpecialist(string name)
        {
            Name = name;
            Applications = new();
        }

        public virtual void Subscribe(ApplicationsHandler provider)
        {
            _cancellation = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            _cancellation.Dispose();
            Applications.Clear();
        }

        public void ListApplications()
        {
            if (Applications.Any())
                foreach (var app in Applications)
                    Console.WriteLine($"Hey, {Name}! {app.ApplicantName} has just applied for job no. {app.JobId}");
            else
                Console.WriteLine($"Hey, {Name}! No applications yet.");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Hey, {Name}! We are not accepting any more applications");
        }

        public void OnError(Exception error)
        {
            // This is called by the provider if any exception is raised, no need to implement it here
        }

        public void OnNext(Application value)
        {
            Applications.Add(value);
        }
    }

    public class ApplicationsHandler : IObservable<Application>
    {
        private readonly List<IObserver<Application>> _observers;
        public List<Application> Applications { get; set; }

        public ApplicationsHandler()
        {
            _observers = new();
            Applications = new();
        }

        public IDisposable Subscribe(IObserver<Application> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                foreach (var item in Applications)
                    observer.OnNext(item);
            }

            return new Unsubscriber(_observers, observer);
        }
        public void AddApplication(Application app)
        {
            Applications.Add(app);

            foreach (var observer in _observers)
                observer.OnNext(app);
        }
        public void CloseApplications()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();

            _observers.Clear();
        }
    }

    public class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<Application>> _observers;
        private readonly IObserver<Application> _observer;

        public Unsubscriber(List<IObserver<Application>> observers, IObserver<Application> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}