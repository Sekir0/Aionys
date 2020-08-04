import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatGridListModule } from '@angular/material/grid-list';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import {TranslateLoader, TranslateModule, TranslateService} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}


import { MainComponent } from './components/main/main.component';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { AddNoteDialogComponent } from './components/add-note-dialog/add-note-dialog.component';
import { NoteTableComponent } from './components/note-table/note-table.component';
import { EditNoteDialogComponent } from './components/edit-note-dialog/edit-note-dialog.component';



@NgModule({
  declarations: [
    MainComponent,
    ConfirmDialogComponent,
    AddNoteDialogComponent,
    NoteTableComponent,
    EditNoteDialogComponent
  ],
  imports: [
    BrowserModule,
    NoopAnimationsModule,
    MatToolbarModule,
    BrowserModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatIconModule,
    MatBottomSheetModule,
    MatDialogModule,
    MatTooltipModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSidenavModule,
    MatPaginatorModule,
    MatGridListModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [

  ],
  bootstrap: [ MainComponent ]
})
export class AppModule { 
  constructor(translate: TranslateService) {
  translate.setDefaultLang('en');
} }
