import { Component } from '@angular/core';
import { Service } from './services/calculator.service';
import { RequeteCalcul } from './models/Calculator.model';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  resultat: any;
  chargement = false;
  erreur: string;
  
  constructor(private Service: Service) { }

  onCalculer(requete: RequeteCalcul) {
    this.chargement = true;
    this.erreur = null;
    this.resultat = null;

    this.Service.calculer(requete).subscribe(
     (resultat) => {
        this.resultat = resultat;
        this.chargement = false;
      },
      (erreur) => {
       this.erreur = 'Erreur lors du calcul';
        this.chargement = false;
        console.error('Détails:', erreur);
      }
    );
  }
}