import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProjectsComponent } from '../projects.component';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})

export class DeleteProjectModalComponent implements OnInit {
  private baseUrl: string;
  @Input() projectId: string;
  deleteForm: FormGroup;
  isSubmitted = false;

  constructor(
    private fb: FormBuilder,
    public modal: NgbActiveModal,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.deleteForm = this.fb.group({ });
  }

  onSubmit(){
    this.isSubmitted = true;

    const options = {
        ProjectId: this.projectId
    };

   this.http.request('delete', this.baseUrl + 'api/projects', { body: options }).subscribe( () =>{ 
    this.modal.close();
    window.location.reload();
   });

  }

}
