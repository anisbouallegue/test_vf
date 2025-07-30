import { Component, Input } from '@angular/core';
import { ResultatCalcul } from '../../models/Calculator.model';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent {
  @Input() resultat: ResultatCalcul;
}