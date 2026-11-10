using System;
using System.Windows;

namespace LocaSIO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshAll();
        }

        private void RefreshAll()
        {
            RefreshAgences_Click(this, new RoutedEventArgs());
            RefreshClients_Click(this, new RoutedEventArgs());
            RefreshArticles_Click(this, new RoutedEventArgs());
        }

        private void RefreshAgences_Click(object sender, RoutedEventArgs e) => Execute(() => AgencesGrid.ItemsSource = AdoAgence.GetAgences(), "Agences chargées.");
        private void RefreshClients_Click(object sender, RoutedEventArgs e) => Execute(() => ClientsGrid.ItemsSource = AdoClient.GetClients(), "Clients chargés.");
        private void RefreshArticles_Click(object sender, RoutedEventArgs e) => Execute(() => ArticlesGrid.ItemsSource = AdoArticle.GetArticles(), "Articles chargés.");

        private void CreateAgence_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AgenceVilleTextBox.Text)) { SetStatus("La ville est obligatoire."); return; }
            Execute(() => { AdoAgence.AddAgence(new Agence(AgenceVilleTextBox.Text.Trim())); RefreshAgences_Click(sender, e); AgenceVilleTextBox.Clear(); }, "Agence créée.");
        }

        private void DeleteAgence_Click(object sender, RoutedEventArgs e)
        {
            if (AgencesGrid.SelectedItem is not Agence agence) { SetStatus("Sélectionnez une agence à supprimer."); return; }
            Execute(() => { AdoAgence.DeleteAgence(agence); RefreshAgences_Click(sender, e); }, "Agence supprimée.");
        }

        private void CreateClient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClientNomTextBox.Text) || string.IsNullOrWhiteSpace(ClientPrenomTextBox.Text) || string.IsNullOrWhiteSpace(ClientEmailTextBox.Text) || string.IsNullOrWhiteSpace(ClientTelephoneTextBox.Text)) { SetStatus("Tous les champs client sont obligatoires."); return; }
            if (!int.TryParse(ClientTelephoneTextBox.Text, out var telephone)) { SetStatus("Le numéro de téléphone est invalide."); return; }
            Execute(() => { AdoClient.AddClient(new Client(ClientNomTextBox.Text.Trim(), ClientPrenomTextBox.Text.Trim(), ClientEmailTextBox.Text.Trim(), telephone)); RefreshClients_Click(sender, e); ClientNomTextBox.Clear(); ClientPrenomTextBox.Clear(); ClientEmailTextBox.Clear(); ClientTelephoneTextBox.Clear(); }, "Client créé.");
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsGrid.SelectedItem is not Client client) { SetStatus("Sélectionnez un client à supprimer."); return; }
            Execute(() => { AdoClient.DeleteClient(client); RefreshClients_Click(sender, e); }, "Client supprimé.");
        }

        private void CreateArticle_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ArticleLibelleTextBox.Text) || !int.TryParse(ArticleTarifTextBox.Text, out var tarif) || !int.TryParse(ArticleCautionTextBox.Text, out var caution) || !int.TryParse(ArticleAgenceIdTextBox.Text, out var agenceId)) { SetStatus("Saisissez un libellé et des nombres valides pour le tarif, la caution et l’agence."); return; }
            Execute(() => { AdoArticle.AddArticle(new Article(ArticleLibelleTextBox.Text.Trim(), tarif, ArticleDisponibleCheckBox.IsChecked == true, caution, agenceId)); RefreshArticles_Click(sender, e); ArticleLibelleTextBox.Clear(); ArticleTarifTextBox.Clear(); ArticleCautionTextBox.Clear(); ArticleAgenceIdTextBox.Clear(); }, "Article créé.");
        }

        private void DeleteArticle_Click(object sender, RoutedEventArgs e)
        {
            if (ArticlesGrid.SelectedItem is not Article article) { SetStatus("Sélectionnez un article à supprimer."); return; }
            Execute(() => { AdoArticle.DeleteArticle(article); RefreshArticles_Click(sender, e); }, "Article supprimé.");
        }

        private void Execute(Action action, string successMessage)
        {
            try { action(); SetStatus(successMessage); }
            catch (Exception exception) { SetStatus($"Erreur : {exception.Message}"); }
        }

        private void SetStatus(string message) => StatusTextBlock.Text = message
    }
}