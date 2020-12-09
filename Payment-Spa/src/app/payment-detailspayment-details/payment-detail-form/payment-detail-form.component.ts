import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PaymentDetail } from 'src/app/models/payment-detail.model';
import { PaymentDetailService } from 'src/app/services/payment-detail.service';

@Component({
  selector: 'app-payment-detail-form',
  templateUrl: './payment-detail-form.component.html',
  styles: [
  ]
})
export class PaymentDetailFormComponent implements OnInit {

  constructor(public service : PaymentDetailService) { }

  ngOnInit(): void {
  }
 
  onSubmit(form : NgForm){
    if(this.service.formData.id==null){
    this.insertRecord(form);
  }
    else{
      this.updateRecord(form);
    }
  
  }
  
  insertRecord(form : NgForm){
    this.service.createPayment().subscribe(
      x =>{
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {console.log(err);}
    )
  }
  resetForm(sended : NgForm){
    sended.form.reset();
    this.service.formData = new PaymentDetail();
  }

  updateRecord(form : NgForm){
    this.service.updatePayment().subscribe(
      x=>{
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }
}

