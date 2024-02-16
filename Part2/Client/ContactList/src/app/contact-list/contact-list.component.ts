import { Component } from '@angular/core';
import { ContactService } from '../service/contact.service';
import { Contact } from '../models/models';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [],
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent {
  contacts: Contact[] = [];

  constructor(private contactService: ContactService) { }
  
  ngOnInit() {
    this.contacts = [{ 'id': 1, 'firstName': 'First', 'lastName': 'Last', 'middleName': 'Middle'}]
    // this.contactService.getContacts().subscribe({ 
    //   next: (contacts) => {
    //     this.contacts = contacts;
    //     console.log(contacts);
    //   }
    // });
  }
}
