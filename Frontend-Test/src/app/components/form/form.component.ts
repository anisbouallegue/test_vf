import { Component, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RequeteCalcul } from 'app/models/Calculator.model';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {
  @Output() calculer = new EventEmitter<RequeteCalcul>();
  formulaire: FormGroup;
  fraisManuels = false;

  constructor(private fb: FormBuilder) {
    this.initialiserFormulaire();
  }

  private initialiserFormulaire(): void {
    this.formulaire = this.fb.group({
      montantAchat: [120000, [Validators.required]],
      fondsPropres: [20000, [Validators.required]],
      dureeMois: [240, [Validators.required]],
      tauxAnnuel: [2.4, [Validators.required]],
      montantEmprunter: [null],
      fraisAchat: [{value: null, disabled: true}]
    });
  }

  onFraisManuelsChange(event: any) {
    this.fraisManuels = event.target.checked;
    const fraisAchatControl = this.formulaire.get('fraisAchat');

    if (this.fraisManuels) {
      fraisAchatControl.enable();
      // const fraisAuto = this.formulaire.get('montantAchat').value > 50000 
      //   ? this.formulaire.get('montantAchat').value * 0.1 
      //   : 0;
      // fraisAchatControl.setValue(fraisAuto);
    } else {
      fraisAchatControl.disable();
      fraisAchatControl.setValue(null);
    }
  }


 onSubmit(): void {
    if (this.formulaire.valid) {
      this.calculer.emit({
        ...this.formulaire.value,
        fraisManuels: this.fraisManuels
      });
    }
  }
}