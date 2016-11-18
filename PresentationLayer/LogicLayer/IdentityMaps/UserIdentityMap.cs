﻿using System.Collections.Generic;
using LogicLayer;

namespace CapstoneRoomScheduler.LogicLayer.IdentityMaps
{
    public class UserIdentityMap
    {
        //default constructor
        private UserIdentityMap() { }
        //an instance
        private static UserIdentityMap instance = new UserIdentityMap();
        //list of all users in active memory
        LinkedList<User> userList_ActiveMemory = new LinkedList<User>();

        public static UserIdentityMap getInstance()
        {
            return instance;
        }

        public void addTo(User user)
        {
            userList_ActiveMemory.AddLast(user);
        }
        
        public void removeFrom(User user)
        {
            userList_ActiveMemory.Remove(user);
        }

        public User findByName(string name)
        {
            foreach (User user in userList_ActiveMemory)
            {
                if (user.name == name)
                {
                    return user;
                }
            }

            return null;
        }

        public User find(int id)
        {
            //for (int i = 0; i < userList_ActiveMemory.Count; i++)
            //{
            //    if (userList_ActiveMemory.ElementAt(i).userID == id)
            //    {
            //        return userList_ActiveMemory.ElementAt(i);
            //    }
            //}
            foreach (User user in userList_ActiveMemory)
            {
                if (user.userID == id)
                {
                    return user;
                }
            }

                return null;
        }

        /**
         * Finds all users that are currently in the active memory
         */
        public Dictionary<int, User> findAll()
        {
            // Create a new dictionary to be returned
            Dictionary<int, User> newDictionary = new Dictionary<int, User>();

            // Copy each key value pairs (do not need to deep copy the value, room).
            // We simply want to not return the reference to the dictionary used here.
            foreach (KeyValuePair<int, User> pair in this.userList_ActiveMemory)
            {
                newDictionary.Add(pair.Key, pair.Value);
            }

            return newDictionary;
        }

    }
}