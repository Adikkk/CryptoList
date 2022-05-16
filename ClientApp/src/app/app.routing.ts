import { RouterModule, Routes } from "@angular/router";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { HomeComponent } from "./home/home.component";
import { ProjectsComponent } from "./projects/projects.component";

const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
    },
    {
        path: 'dashboard',
        children: [{ path: '', component: DashboardComponent }]
    },
    {
        path: 'projects',
        children: [{ path: '', component: ProjectsComponent }]
    }
];

export const RoutingModule = RouterModule.forRoot(routes);