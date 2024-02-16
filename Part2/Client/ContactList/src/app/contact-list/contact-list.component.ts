import { Component } from '@angular/core';
import { ContactService } from '../service/contact.service';
import { Contact } from '../models/models';
import { NgFor } from '@angular/common';
import { Router } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [NgFor, MatTableModule, MatPaginatorModule],
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent {
  contacts: Contact[] = [];
  displayedColumns = ["id", "firstName", "middleName", "lastName"];

  constructor(private contactService: ContactService, private router: Router) { }
  
  ngOnInit() {
    this.contacts = [{ id: 1, firstName: 'John', lastName: 'Smith', middleName: 'Middle'},
                     { id: 2, firstName: 'Jane', lastName: 'Doe', middleName: 'Middle'}]
    // this.contactService.getContacts().subscribe({ 
    //   next: (contacts) => {
    //     this.contacts = contacts;
    //     console.log(contacts);
    //   }
    // });
  }

  navigateTo(id: number) {
    this.router.navigate(['contact-details', id]);
  }
}
