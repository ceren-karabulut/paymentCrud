import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { strict } from 'assert';
import { PaymentDetailService } from '../services/payment-detail.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styles: [
  ]
})
export class PaymentDetailsComponent implements OnInit {

  constructor(public service : PaymentDetailService) { }

 
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord){
 this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id){
    this.service.deletePayment(id)
    .subscribe(x=> {
      this.service.refreshList()
    },
    err=> {
      console.log(err)
    })
  }
    
  }

