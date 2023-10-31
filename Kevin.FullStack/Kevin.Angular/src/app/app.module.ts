import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// to work with Reactive Forms
import { ReactiveFormsModule } from '@angular/forms';

// to work with Http Request/Client
import { HttpClientModule } from '@angular/common/http';

// to work with Angular Material Tables
import { MatTableModule } from '@angular/Material/table';
import { MatPaginatorModule } from '@angular/Material/paginator';

// to work with Angular Material Controls
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MomentDateModule } from '@angular/material-moment-adapter';

// to work with Angular alert messages
import { MatSnackBarModule } from '@angular/material/snack-bar';

// to work with Angular Material Icons
import { MatIconModule } from '@angular/material/icon';

// to work with Angular Material Modals
import { MatDialogModule } from '@angular/material/dialog';

// to work with Angular Material Grids
import { MatGridListModule } from '@angular/material/grid-list';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MomentDateModule,
    MatSnackBarModule,
    MatIconModule,
    MatDialogModule,
    MatGridListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
