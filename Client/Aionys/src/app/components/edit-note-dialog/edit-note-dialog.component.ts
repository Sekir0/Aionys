import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConfirmDialogModel } from '../../models/confirm-dialog.model';
import { NoteModel } from '../../models/note.model';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-edit-note-dialog',
  templateUrl: './edit-note-dialog.component.html',
  styleUrls: ['./edit-note-dialog.component.scss']
})
export class EditNoteDialogComponent implements OnInit {
  form: FormGroup;
  constructor(
    public noteDialog: MatDialogRef<EditNoteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: NoteModel,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.form = new FormGroup({
      curName: new FormControl('', Validators.required)
    });
  }

  onEdit(): void {
    const message = `Edit?`;

    const dialogData = new ConfirmDialogModel('Confirm Edit', message);

    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: '400px',
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult === true) {
        this.noteDialog.close({
          id: this.data.id,
          name: this.data.name
        });
      }
    });
  }

  onCancel(): void {
    this.noteDialog.close();
  }

}
