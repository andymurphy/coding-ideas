using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using CodingIdeas.Models;

namespace CodingIdeas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles the user clicking the Add Idea Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewIdeaButton_Clicked(object sender, EventArgs e)
        {
            // Get the user's idea text from the UI
            string ideaName = newIdeaName.Text;
            string ideaDescription = newIdeaDescription.Text;
            // Use the method from the idea repository class to add a new idea to the SQLite database
            App.ideaRepository.AddNewIdea(ideaName, ideaDescription);
            statusMessage.Text = App.ideaRepository.StatusMessage;
        }

        /// <summary>
        /// Handles the user clicking the Show Ideas button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllIdeasButton_Clicked(object sender, EventArgs e)
        {
            // Clear the staus message text
            statusMessage.Text = "";
            // Get all the ideas from the repository
            List<Idea> allIdeas = App.ideaRepository.GetAllIdeas(); // Needed to add using CodingIdeas.Models up at the top.
            // Set the item source of the listview to be the ideas we got from the repository
            ideasList.ItemsSource = allIdeas;
        }
    }
}
