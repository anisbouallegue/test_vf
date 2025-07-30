import { Component, Input } from '@angular/core';
import { LigneAmortissement } from '../../models/Calculator.model';
@Component({
  selector: 'app-amortissement-table',
  templateUrl: './amortissement-table.component.html',
  styleUrls: ['./amortissement-table.component.css']
})
export class AmortissementTableComponent {
  @Input() amortissement:  LigneAmortissement[];
}