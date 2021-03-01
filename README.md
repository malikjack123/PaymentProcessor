# payment-processor
Payment Processor
***

***

### Example of POSTMAN call

Call URL https://localhost:44302/api/pay/ProcessPayment with POST
with JSON:
```json
{
	"creditCardNumber": "5402 6326 4830 4155",
	"cardHolder" : "Usama Malik",
	"expirationDate" : "2021-01-02",
	"securityCode" : "123",
	"amount" : 21
}



{
    "CreditCardNumber": "23",
    "CardHolder": "Red",
    "ExpirationDate": "2021-03-01T17:32:45.9514674+00:00",
    "SecurityCode": "123",
    "Amount": 20.2
}
```
 


