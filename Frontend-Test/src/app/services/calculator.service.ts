// prêt.service.ts
import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { RequeteCalcul, ResultatCalcul } from '../models/Calculator.model';

@Injectable()
export class Service {
  private apiUrl = 'https://localhost:44354/api/v1/calculate'; 

  constructor(private http: Http) { }

  calculer(requete: RequeteCalcul): Observable<ResultatCalcul> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const options = new RequestOptions({ headers });

    return this.http.post(this.apiUrl, JSON.stringify(requete), options)
      .map((reponse: any) => reponse.json())
      .catch(this.gestionErreur);
  }

  private gestionErreur(erreur: any) {
    console.error('Erreur API:', erreur);
    return Observable.throw(erreur.message || 'Erreur serveur');
  }
}