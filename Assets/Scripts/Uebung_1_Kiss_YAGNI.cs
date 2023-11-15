/*
Übung: Refaktorisierung eines Spiele-Updatesystems

Ziel:
Refaktorisieren Sie ein bestehendes Spiele-Update-System, das aktuell zu komplex ist und Funktionen enthält, die nicht benötigt werden.
Ein klarer und einfacher Code, der die Funktionalität des Update-Systems verbessert.

Vorbereitung:
1. Erstellen Sie eine private GitHub-Repository mit dem Namen "C#_Styleguide_[IhrName]" und verknüpfen Sie ein Unity Projekt(3D-Core) mit dieser + Initial Push.
2. Fügen Sie oli90martin@web.de als Collaborator zu Ihrer Repository hinzu.

Kontext:
Sie haben ein Update-System für ein Spiel geerbt, das während des Spiels prüft, ob Updates verfügbar sind. Der vorhandene Code ist kompliziert und berücksichtigt verschiedene Szenarien, die das aktuelle Spiel nicht unterstützt, wie spezielle Ereignisse oder unterschiedliche Netzwerkstatus.

Aufgaben:

Vereinfachen Sie das Update-System:
Entfernen Sie alle Code-Teile, die nicht unmittelbar mit dem Aktualisieren des Spiels zusammenhängen.
Beschränken Sie sich auf die grundlegenden Funktionen: Prüfen, ob das Spiel läuft, ob eine Internetverbindung besteht, ob ein Update verfügbar ist, und auf das Anwenden des Updates.

Anwendung des KISS-Prinzips:
Der Code sollte direkt und verständlich sein. Vermeiden Sie unnötige Abfragen und Zustandsprüfungen.

Anwendung des YAGNI-Prinzips:
Entfernen Sie vorbereitende Schritte für Features, die nicht in der aktuellen Version des Spiels verwendet werden, wie z.B. das Handling von speziellen Ereignissen oder Multiplayer-Sitzungen.

Nachbereitung:
Pushen Sie den refaktorisierten Code zu Ihrer GitHub-Repository.
*/

class GameUpdater {
    public void CheckForUpdates(Game game) {
        if (game.Status == "Running") {
            throw new InvalidOperationException("Cannot update while game is running.");
        }

        // Simulation verschiedener Netzwerkstatus
        NetworkStatus networkStatus = game.CheckNetworkStatus();
        if (networkStatus == NetworkStatus.Disconnected) {
            throw new NoNetworkConnectionException("Please check your internet connection.");
        } else if (networkStatus == NetworkStatus.Connected) {
            bool updatesAvailable = game.CheckForGameUpdates();
            if (updatesAvailable) {
                game.DownloadGameUpdates();
                // Überprüfung auf spezielle Ereignisse
                if (game.HasSpecialEvents()) {
                    game.PrepareForSpecialEvents();
                }
                game.ApplyUpdates();
                Console.WriteLine("Game updated successfully.");
            } else {
                Console.WriteLine("No updates available.");
            }
        }
    }
}

enum NetworkStatus {
    Disconnected,
    Connected
}

class Game {
    public string Status { get; set; }
    
    public NetworkStatus CheckNetworkStatus() {
        // Simuliert eine Netzwerkstatusprüfung
        return NetworkStatus.Connected;
    }

    public bool CheckForGameUpdates() {
        // Simuliert eine Überprüfung auf Spielupdates
        return true;
    }

    public void DownloadGameUpdates() {
        // Simuliert das Herunterladen von Updates
    }

    public bool HasSpecialEvents() {
        // Simuliert die Überprüfung auf spezielle Ereignisse
        return false;
    }

    public void PrepareForSpecialEvents() {
        // Simuliert die Vorbereitung auf spezielle Ereignisse
    }

    public void ApplyUpdates() {
        // Simuliert das Anwenden von Updates
    }
}
