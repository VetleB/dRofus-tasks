import { Routes } from '@angular/router';
import { ContactListComponent } from './contact-list/contact-list.component';
import { ContactDetailComponent } from './contact-detail/contact-detail.component';

export const routes: Routes = [
    { path: '', redirectTo: 'contact-list', pathMatch: 'full' },
    { path: 'contact-list', component: ContactListComponent, pathMatch: 'full' },
    { path: 'contact-details/:id', component: ContactDetailComponent },
];
