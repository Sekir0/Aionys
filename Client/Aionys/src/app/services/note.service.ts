import { Injectable } from '@angular/core';
import { NoteModel } from '../models/note.model';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap, delay } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class NoteService {
    public notes$: BehaviorSubject<NoteModel[]> = new BehaviorSubject([]);
    private readonly baseUrl = 'https://localhost:5001/api/v1/notes';

    constructor(private http: HttpClient) {}

    public updateNotes() {
        return this.getNotes().pipe(
          tap(data => {
            this.notes$.next(data);
          })
        );
    }

    public getNotes(): Observable<any>{
        return this.http.get<NoteModel[]>(`${this.baseUrl}`);
    }

    public addNote(note: NoteModel){
        return this.http.post(`${this.baseUrl}`, note);
    }

    public removeNote(note: NoteModel) {
        return this.http.delete(`${this.baseUrl}/${note.id}`);
    }

    public editNote(note: NoteModel) {
        return this.http.put(`${this.baseUrl}/${note.id}`, {
          name: note.name
        });
    }
}
