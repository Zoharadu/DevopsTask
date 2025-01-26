import { Routes } from '@angular/router';
import { ServicesComponent } from './components/services/services.component';

export const routes: Routes = [
    { path: '', redirectTo: 'api', pathMatch: 'full' }, 
    { path: 'services', component: ServicesComponent },
    { path: 'api', redirectTo: '', pathMatch: 'full' }, 
    { path: '**', redirectTo: '' }
];





