import { Component, OnInit, ViewChild } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { MatDialog } from "@angular/material/dialog";
import { ConfirmDialogComponent } from "../confirm-dialog/confirm-dialog.component";
import { AddNoteDialogComponent } from "../add-note-dialog/add-note-dialog.component";
import { NoteModel } from "../../models/note.model";
import { NoteService } from "../../services/note.service";
import { ConfirmDialogModel } from '../../models/confirm-dialog.model';
import { EditNoteDialogComponent } from '../edit-note-dialog/edit-note-dialog.component';


@Component({
  selector: 'app-note-table',
  templateUrl: './note-table.component.html',
  styleUrls: ['./note-table.component.scss']
})
export class NoteTableComponent implements OnInit {
  public displayedColumns: string[] = ["name"];
  public notesArr = new MatTableDataSource<NoteModel>();
  public extandDetail: NoteModel;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private _noteService: NoteService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this._noteService.getNotes().subscribe(data => {
      this.notesArr.data = data.data;
      this.notesArr.paginator = this.paginator;
    });
 }

  public removeNote(note: NoteModel) {
    const message = 'Done?';
    const dialogData = new ConfirmDialogModel("Confirm Edit", message);
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: "400px",
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this._noteService
          .removeNote(note)
          .subscribe(() => this._noteService.updateNotes().subscribe());
      }
    });
  }

  public addNote() {
    const dialogRef = this.dialog.open(AddNoteDialogComponent, {
      width: "500px"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== false) {
        this._noteService
          .addNote(result)
          .subscribe(() => this._noteService.updateNotes().subscribe());
      }
    });
  }

  public editNote(note: NoteModel) {
    const dialogRef = this.dialog.open(EditNoteDialogComponent, {
      width: "500px",
      data: {
        id: note.id,
        name: note.name
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != null) {
        this._noteService
          .editNote(result)
          .subscribe(() => this._noteService.updateNotes().subscribe());
      }
    });
  }

  public refreshNotesList() {
    this._noteService.updateNotes().subscribe();
  }
}
