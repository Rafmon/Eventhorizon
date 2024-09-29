using System.Collections;
using EventHorizon.src.Util;

namespace EventHorizon.src.Events
{
	public class EventManager
	{
		public List<Event> Events { get;}
            
		public EventManager()
		{
            Console.WriteLine("init EventManager");
            Events = SaveManager.LoadEvents();
            if (Events.Count <= 0 )
			{
				CreateSomeEvents();
			}
            Console.WriteLine("Done init EventManager");
        }

        private void CreateSomeEvents()
        {
			Event e112 = new Event();
			e112.EventStart = new TimeOnly(10, 30);
			e112.EventEnd = new TimeOnly(17, 30);
			e112.Address = 112;
			e112.Name = "Eisdiele";
			Events.Add(e112);

            Event e113 = new Event();
            e113.EventStart = new TimeOnly(10, 00);
            e113.EventEnd = new TimeOnly(18, 00);
            e113.Address = 113;
			e113.Name = "Geschäft";
            Events.Add(e113);

			Event e114 = new Event ();
			e114.EventStart = new TimeOnly(14, 30);
			e114.EventEnd = new TimeOnly(00, 30);
			e114.Address = 114;
			e114.Name = "Türmchen auf der Mauer";
            Events.Add(e114);

			Event e115 = new Event ();
			e115.EventStart = new TimeOnly(18, 12);
			e115.EventEnd = new TimeOnly(22, 57);
			e115.Address = 115;
			e115.IsEventStartRandom = true;
			e115.IsEventEndRandom = true;
			e115.Name = "normales haus";
            Events.Add(e115);

			Event e116 = new Event ();
			e116.EventStart = new TimeOnly(11, 30);
			e116.EventEnd = new TimeOnly(19, 30);
			e116.Address = 114;
			e116.Name = "laden";
            Events.Add(e116);

			Event e117 = new Event ();
			e117.EventStart = new TimeOnly(17, 00);
			e117.EventEnd = new TimeOnly(23, 30);
			e117.Address = 117;
			e117.Name = "Wirtschaft";
            Events.Add(e117);

			Event e118 = new Event ();
			e118.EventStart = new TimeOnly(17, 30);
			e118.EventEnd = new TimeOnly(6, 30);
			e118.Address = 118;
			e118.Name = "Lichter neue stadt";
            Events.Add(e118);

			Event e119 = new Event ();
			e119.EventStart = new TimeOnly(16, 30);
			e119.EventEnd = new TimeOnly(7, 30);
			e119.Address = 119;
			e119.Name = "Lichter altstadt";
            Events.Add(e119);

			Event e120 = new Event ();
			e120.EventStart = new TimeOnly(11, 30);
			e120.EventEnd = new TimeOnly(19, 30);
			e120.Address = 120;
			e120.Name = "Gaststätte";
            Events.Add(e120);

			Event e121 = new Event ();
			e121.EventStart = new TimeOnly(15, 30);
			e121.EventEnd = new TimeOnly(00, 00);
			e121.Address = 121;
			e121.Name = "Gaststätte";
            Events.Add(e121);

			Event e122 = new Event ();
			e122.EventStart = new TimeOnly(11, 00);
			e122.EventEnd = new TimeOnly(19, 00);
			e122.Address = 122;
			e122.Name = "Geschäft";
            Events.Add(e122);

			Event e123 = new Event ();
			e123.EventStart = new TimeOnly(17, 30);
			e123.EventEnd = new TimeOnly(21, 30);
			e123.Address = 123;
			e123.Name = "Wohnhaus";
			e123.IsEventStartRandom = true;
			e123.IsEventEndRandom = true;
            Events.Add(e123);

			Event e124 = new Event ();
			e124.EventStart = new TimeOnly(10, 00);
			e124.EventEnd = new TimeOnly(17, 30);
			e124.Address = 124;
			e124.Name = "Geschäft";
            Events.Add(e124);

			Event e125 = new Event ();
			e125.EventStart = new TimeOnly(20, 00);
			e125.EventEnd = new TimeOnly(1, 30);
			e125.Address = 125;
			e125.IsEventStartRandom = true;
			e125.IsEventEndRandom = true;
			e125.Name = "Wohnhaus Römerzeile Ecke";
            Events.Add(e125);

			Event e126 = new Event ();
			e126.EventStart = new TimeOnly(10, 30);
			e126.EventEnd = new TimeOnly(00, 30);
			e126.Address = 126;
			e126.Name = "Kirche";
            Events.Add(e126);

			Event e127 = new Event ();
			e127.EventStart = new TimeOnly(6, 30);
			e127.EventEnd = new TimeOnly(13, 30);
			e127.Address = 127;
			e127.Name = "Feinkostladen";
            Events.Add(e127);

		}

        public void RemoveEvent(Event e)
        {
            if (e == null) return;

            Events.Remove(e);
            SaveManager.SaveEvents(Events);
        }

        public void AddEvent(Event e)
        {
            if (e == null) return;

            Events.Add(e);
            SaveManager.SaveEvents(Events);
        }


    }
}

