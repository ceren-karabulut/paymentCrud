import { Injectable } from '@angular/core';
import {PaymentDetail} from 'src/app/models/payment-detail.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {

  formData : PaymentDetail
  readonly baseUrl : "https://localhost:44310/api/Payment"
  paymentList : PaymentDetail[]

  constructor(private http : HttpClient) { }

  createPayment(){
    return this.http.post(this.baseUrl, this.formData);
  }

  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(x=>this.paymentList = x as PaymentDetail[])
  }

  updatePayment(){
    return this.http.put("${this.baseUrl}/${this.formData.id}",this.formData);
  }
  
  deletePayment(id){
    return this.http.delete("${this.baseUrl}/${id}");
  }

  
}
