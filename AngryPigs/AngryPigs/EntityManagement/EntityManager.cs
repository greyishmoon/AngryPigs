using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngryPigs.GameEntitites;

namespace AngryPigs.EntityManagement
{
    class EntityManager
    {

        #region FIELDS

        // <game engine class> automatically created and stored as static field - enforces threadsafe singleton pattern
        private static readonly EntityManager singleton = new EntityManager();

        // Counter for unique entity ID's
        private int mUniqueIDCount;

        #endregion

        #region PROPERTIES

        //PROPERTIES

        #endregion

        #region CONSTRUCTOR

        // Threadsafe singleton pattern - this pattern was chosen as it simplifies threadsafe singleton checking by not requiring locks,
        // but at the cost of not being fully lazy. This was considered optimal in this situation as we will always want the game engine classes 
        // instantiating and just want to ensure no others are created - pattern source: http://csharpindepth.com/Articles/General/Singleton.aspx

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static EntityManager()
        {
        }

        // private constructor - enforces threadsafe singleton pattern
        private EntityManager()
        {
            // set unique ID's to zero on creation
            mUniqueIDCount = 0;
        }

        // Static property to access single Kernel object - enforces threadsafe singleton pattern
        public static EntityManager Instance
        {
            get
            {
                return singleton;
            }
        }

        #endregion

        #region INITIALISE

        //INITIALISE

        #endregion

        #region METHODS

        // Dynamic object creation: create and return new entity based on type
        // Generic method
        // Dynamic return type
        // use generic variant of CreateInstance from Activator class within the root System namespace
        // ref: http://msdn.microsoft.com/en-us/library/system.activator.createinstance.aspx, 
        // source http://stackoverflow.com/questions/752/get-a-new-object-instance-from-a-type       
        public dynamic RequestEntity<T>()
        {
            dynamic newEntity;
            
            // create object based on type
            newEntity = Activator.CreateInstance<T>();

            // assign and initialise base entity fields with name 
            // get next ID to be assigned
            int assignID = mUniqueIDCount;
            // increment ID count
            mUniqueIDCount++;
            // construct unique ID based on entity type and unique ID
            //Type entityType = typeof(T);
            string assignName = (typeof(T).Name + assignID);
            // Assign ID and name
            newEntity.SetUp(assignID, assignName);
            
            // return initialised entity
            return newEntity;

        }



        #endregion

    }
}
