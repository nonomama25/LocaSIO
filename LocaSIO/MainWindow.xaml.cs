using System;
using System.Windows;
using System.Collections.ObjectModel;

namespace LocaSIO
{
    public partial class MainWindow : Window
    {
        private int? selectedContratClientId;

        public MainWindow()
        {
            InitializeComponent();
            RefreshAgences_Click(this, new RoutedEventArgs());
            RefreshAll();
        }

        private void OpenClientContrat_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not FrameworkElement { DataContext: Client client })
            {
                SetStatus("Impossible de récupérer le client sélectionné.");
                return;
            }

            selectedContratClientId = client.Id;
            ContratClientContextTextBlock.Text = $"{client.Id} - {client.Nom} {client.Prenom}";
            MainTabControl.SelectedIndex = 3;
            RefreshContrats_Click(sender, e);
        }

        private void RefreshAll()
        {
            RefreshAgences_Click(this, new RoutedEventArgs());
            RefreshClients_Click(this, new RoutedEventArgs());
            RefreshArticles_Click(this, new RoutedEventArgs());
            RefreshContrats_Click(this, new RoutedEventArgs());
        }

        private void RefreshAgences_Click(object sender, RoutedEventArgs e) {
            try
            {
                var agences = AdoAgence.GetAgences();
                AgencesGrid.ItemsSource = agences;
                ArticleAgenceComboBox.ItemsSource = agences;
            }
            catch (Exception ex)
            {
                SetStatus($"Erreur : {ex.GetBaseException().Message}");
            }
        }

        private void RefreshClients_Click(object sender, RoutedEventArgs e) => Execute(() => ClientsGrid.ItemsSource = AdoClient.GetClients(), "Clients chargés.");
        private void RefreshArticles_Click(object sender, RoutedEventArgs e) => Execute(() => ArticlesGrid.ItemsSource = AdoArticle.GetArticles(), "Articles chargés.");
        private void RefreshContrats_Click(object sender, RoutedEventArgs e) => Execute(() => ContratsGrid.ItemsSource = AdoContrat.GetContrats(), "Contrats chargés.");

       private void CreateAgence_Click(object sender, RoutedEventArgs e)
{
    string ville = AgenceVilleTextBox.Text;
    Agence agence = new Agence(ville, "");
    AdoAgence.AddAgence(agence);
    RefreshAgences_Click(sender, e);
    AgenceVilleTextBox.Clear();
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
            Execute(() => { AdoClient.AddClient(new Client(ClientNomTextBox.Text.Trim(), ClientPrenomTextBox.Text.Trim(), ClientEmailTextBox.Text.Trim(), ClientTelephoneTextBox.Text.Trim())); RefreshClients_Click(sender, e); ClientNomTextBox.Clear(); ClientPrenomTextBox.Clear(); ClientEmailTextBox.Clear(); ClientTelephoneTextBox.Clear(); }, "Client créé.");
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsGrid.SelectedItem is not Client client) { SetStatus("Sélectionnez un client à supprimer."); return; }
            Execute(() => { AdoClient.DeleteClient(client); RefreshClients_Click(sender, e); }, "Client supprimé.");
        }

        private void CreateArticle_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ArticleLibelleTextBox.Text) || !int.TryParse(ArticleTarifTextBox.Text, out var tarif) || !int.TryParse(ArticleCautionTextBox.Text, out var caution) || ArticleAgenceComboBox.SelectedValue is not int agenceId) { SetStatus("Saisissez un libellé, des nombres valides pour le tarif et la caution, et sélectionnez une agence."); return; }
            Execute(() => { AdoArticle.AddArticle(new Article(ArticleLibelleTextBox.Text.Trim(), tarif, caution, agenceId); RefreshArticles_Click(sender, e); ArticleLibelleTextBox.Clear(); ArticleTarifTextBox.Clear(); ArticleCautionTextBox.Clear();}, "Article créé.");
        }

        private void DeleteArticle_Click(object sender, RoutedEventArgs e)
        {
            if (ArticlesGrid.SelectedItem is not Article article) { SetStatus("S?lectionnez un article ? supprimer."); return; }
            Execute(() => { AdoArticle.DeleteArticle(article); RefreshArticles_Click(sender, e); }, "Article supprimé.");
        }

        private void CreateContrat_Click(object sender, RoutedEventArgs e)
        {
            if (selectedContratClientId is not int clientId)
            {
                SetStatus("Ouvrez les contrats depuis un client pour associer le contrat.");
                return;
            }

            if (ContratDateDebutPicker.SelectedDate is not DateTime dateDebut || ContratDateFinPicker.SelectedDate is not DateTime dateFin)
            {
                SetStatus("Sélectionnez les dates de début et de fin du contrat.");
                return;
            }

            if (dateFin < dateDebut || string.IsNullOrWhiteSpace(ContratStatutTextBox.Text) || string.IsNullOrWhiteSpace(ContratDistinguishedNameTextBox.Text))
            {
                SetStatus("La date de fin doit être postérieure au début et les champs texte sont obligatoires.");
                return;
            }

            Execute(() =>
            {
                AdoContrat.AddContrat(new Contrat(clientId, dateDebut, dateFin, ContratStatutTextBox.Text.Trim(), ContratDistinguishedNameTextBox.Text.Trim()));
                RefreshContrats_Click(sender, e);
                ContratDateDebutPicker.SelectedDate = null;
                ContratDateFinPicker.SelectedDate = null;
                ContratStatutTextBox.Clear();
                ContratDistinguishedNameTextBox.Clear();
            }, "Contrat créé.");
        }

        private void DeleteContrat_Click(object sender, RoutedEventArgs e)
        {
            if (ContratsGrid.SelectedItem is not Contrat contrat) { SetStatus("Sélectionnez un contrat à supprimer."); return; }
            Execute(() => { AdoContrat.DeleteContrat(contrat); RefreshContrats_Click(sender, e); }, "Contrat supprimé.");
        }

        private void Execute(Action action, string successMessage)
        {
            try { action(); SetStatus(successMessage); }
            catch (Exception exception) { SetStatus($"Erreur : {exception.GetBaseException().Message}"); }
        }

        private void SetStatus(string message) => StatusTextBlock.Text = message;
    }
}