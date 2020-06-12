﻿using System;
using System.Collections.Generic;
using CodingIdeas.Models;
using SQLite;

namespace CodingIdeas
{
    public class IdeaRepository
    {
        // Properties for the class
        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        // Constructor for the class
        public IdeaRepository(string dbPath)
        {
            // Initialise the SQLite Connection
            conn = new SQLiteConnection(dbPath);
            // Create the person table in the database
            conn.CreateTable<Idea>();
        }

        // Class methods

        /// <summary>
        /// Adds a new row to the Idea table
        /// </summary>
        /// <param name="ideaDescription">The description of the idea from the input box on th UI</param>
        public void AddNewIdea(string ideaName, string ideaDescription)
        {
            int result;
            try
            {
                Idea idea = new Idea { Name = ideaName, Description = ideaDescription, DateAdded = DateTime.Now };
                result = conn.Insert(idea);
                StatusMessage = "Added " + ideaName + " successfully!"; // could be done with string.Format
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", ideaDescription, ex.Message);
            }
        }                

        /// <summary>
        /// Gets all the ideas from the database
        /// </summary>
        /// <returns>A list of type Ideas</returns>
        public List<Idea> GetAllIdeas()
        {
            try
            {
                List<Idea> ideas = conn.Table<Idea>().ToList();
                return ideas;
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Idea>();
        }
    }
}
