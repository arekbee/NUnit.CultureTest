using NUnit.Framework;



    public abstract class CultureTests
    {
        public const string DefaultCulture = "en-US";

        [TestFixtureSetUp]
        public virtual void Setup()
        {
            Console.WriteLine( CultureIs());
            ChangeCulture();
        }

        [TestFixtureTearDown]
        public virtual void Teardown()
        {
            Console.WriteLine();
        }

        public virtual string CultureIs()
        {
            return String.Format("{0}/{1}", Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentUICulture);
        }


        public virtual void ChangeCulture()
        {
            string culture = CultureName;
            if (String.IsNullOrWhiteSpace(culture))
            {
                culture = DefaultCulture;
            }
            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
        }

        public virtual string CultureName { get; set; }

        public static List<Type> GetTypesFromAssemblyName(string name)
        {
            string location = Assembly.GetExecutingAssembly().Location;
            Assembly assembly = Assembly.Load(Path.GetFileNameWithoutExtension(Path.Combine(location, name)));
            var classes = assembly.GetTypes().Where(x => x.IsClass);
            var testClasses = classes.Where(t => t.GetMethods().Any(m => m.GetCustomAttributes(typeof(TestAttribute), false).Any()));
            return testClasses.ToList();
        }
    }

   

    public class GermanCT : CultureTests
    {
        public override string CultureName {
            get
            {
                return "de-DE";
            }
        }

        [Suite]
        public static IEnumerable Suite
        {
            get
            {
                return GetTypesFromAssemblyName(  "SampleTests.dll");
            }
        }
    }

    public class HungarianCT : CultureTests
    {
        public override string CultureName
        {
            get
            {
                return "hu-HU";
            }
        }

        [Suite]
        public static IEnumerable Suite
        {
            get
            {
                return GetTypesFromAssemblyName("SampleTests.dll");
            }
        }
    }

    public class KoreanCT : CultureTests
    {
        public override string CultureName
        {
            get
            {
                return "ko-KR";
            }
        }

        [Suite]
        public static IEnumerable Suite
        {
            get
            {
                return GetTypesFromAssemblyName("SampleTests.dll");
            }
        }
    }

    public class PolishCT : CultureTests
    {
        public override string CultureName
        {
            get
            {
                return "pl-PL";
            }
        }

        [Suite]
        public static IEnumerable Suite
        {
            get
            {
                return GetTypesFromAssemblyName("SampleTests.dll");
            }
        }
    }

    public class TurkishCT : CultureTests
    {
        public override string CultureName
        {
            get
            {
                return "tr-TR";
            }
        }

        [Suite]
        public static IEnumerable Suite
        {
            get
            {
                return GetTypesFromAssemblyName("SampleTests.dll");
            }
        }
    }
