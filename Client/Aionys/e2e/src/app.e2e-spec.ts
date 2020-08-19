import { TestBed, inject } from '@angular/core/testing';
import { HttpClientModule, HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { AppPage } from './app.po';
import { browser, logging } from 'protractor';
import { NoteModel } from 'src/app/models/note.model';
import { NoteService } from 'src/app/services/note.service';

const mockData = [
  {id: 1, name: "note1"},
  {id: 2, name: "note2"},
  {id: 3, name: "note3"},
  {id: 4, name: "note4"}
] as NoteModel[];

describe('NoteService', () => {
  let service;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        NoteService
      ]
    });
    httpTestingController = TestBed.get(HttpTestingController);
  });

  beforeEach(inject([NoteService], s => {
    service = s;
  }));

  beforeEach(() => {
    this.mockNotes = [...mockData];
    this.mockNote = this.mockNotes[0];
    this.mockId = this.mockNote.id;
  });

  const apiUrl = (id?: number) => {
    return `http://localhost:4200/`;
  };

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('getNotes', () => {
    it('should return mocked notes', () => {
      service.getNotes().subscribe(
        notes => expect(notes.length).toEqual(this.mockNotes.length),
        fail
      );
      const req = httpTestingController.expectOne(service.notesUrl);
      expect(req.request.method).toEqual('GET');
      req.flush(this.mockNotes);
    });
  });
});
