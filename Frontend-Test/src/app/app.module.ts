import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { FormComponent } from './components/form/form.component';
import { ResultComponent } from './components/result/result.component';
import { AmortissementTableComponent } from './components/amortissement-table/amortissement-table.component';
import { Service } from './services/calculator.service';

@NgModule({
  declarations: [
    AppComponent,
    FormComponent,
    ResultComponent,
    AmortissementTableComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule
  ],
  providers: [Service],
  bootstrap: [AppComponent]
})
export class AppModule { }