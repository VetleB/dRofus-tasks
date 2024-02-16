import { Component } from '@angular/core';
import { Contact } from '../models/models';
import { ContactService } from '../service/contact.service';
import { ActivatedRoute, Route } from '@angular/router';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [],
  templateUrl: './contact-detail.component.html',
  styleUrl: './contact-detail.component.css'
})
export class ContactDetailComponent {
  contact: Contact;
  id: string;

  constructor(private contactService: ContactService, public route: ActivatedRoute) { }
  
  ngOnInit() {
    this.contact = { id: 1, firstName: 'John', lastName: 'Smith', middleName: 'Middle'}
    this.id = this.route.snapshot.params['id'];
    console.log(this.id)
    // this.contactService.getContacts().subscribe({ 
    //   next: (contacts) => {
    //     this.contacts = contacts;
    //     console.log(contacts);
    //   }
    // });
  }
}
