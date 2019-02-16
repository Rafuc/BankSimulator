import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule, NoopAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule, MatGridListModule, MatCardModule, MatMenuModule, MatIconModule, MatInputModule, MatSelectModule, MatRadioModule} from '@angular/material';



import { AppComponent } from './app.component';
import { LayoutModule } from '@angular/cdk/layout';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';


@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      
   ],
   imports: [
      BrowserAnimationsModule,
      NoopAnimationsModule,
      MatButtonModule, 
      MatCheckboxModule,
      BrowserModule,
      MatGridListModule,
      MatCardModule,
      MatMenuModule,
      MatIconModule,
      LayoutModule,
      MatInputModule,
      MatSelectModule,
      MatRadioModule,
      ReactiveFormsModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

export class PizzaPartyAppModule { }
