import { Component } from '@angular/core';
import { Contact } from '../models/models';
import { ContactService } from '../service/contact.service';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [],
  templateUrl: './contact-detail.component.html',
  styleUrl: './contact-detail.component.css'
})
export class ContactDetailComponent {
  contact: Contact;

  constructor(private contactService: ContactService) { }
  
  ngOnInit() {
    this.contact = { 'id': 1, 'firstName': 'First', 'lastName': 'Last', 'middleName': 'Middle'}
    // this.contactService.getContacts().subscribe({ 
    //   next: (contacts) => {
    //     this.contacts = contacts;
    //     console.log(contacts);
    //   }
    // });
  }
}
