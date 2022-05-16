import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddProjectModalComponent } from './add/add/add.component';
import { DeleteProjectModalComponent } from './delete/delete.component';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {
  private baseUrl: string;
  projects: Project[];

  constructor(
    private modalService: NgbModal,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
   }

  ngOnInit() {
    this.http.get<any>(this.baseUrl + 'api/projects')
    .subscribe(data => {
      this.projects = data;
      console.log(this.projects)
      })
    };

    openAddProjectModal() {
       this.modalService.open(AddProjectModalComponent);
    }

    openDeleteProjectModal(projectId: string) {
      const deleteModal = this.modalService.open(DeleteProjectModalComponent);
      deleteModal.componentInstance.projectId = projectId;
    }
  }

interface Project {
  Id: string;
  UserId: string;
  Name: string;
  Link: string;
  Description: string;
  Category: string;
  ISOCode: string;
  PictureUri: string;
  IsPremium: boolean;
}
