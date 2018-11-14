Software Engineering Methods @ Edinburgh Napier University

Task: "Build-A-Bike" offers customers the ability to custom design and purchase their own Road
Bike or Mountain Bike using a simple stage based system that lets them pick between
standard and custom components: Details of the customers choices are entered into the
system by the receptionist. First the user chooses a frame ( Size and Colour), then “group
set” (gears and brakes), then wheels, and then “finishing set” (handlebars and saddle). The
system displays the cost of the bike, based upon the price of the individual components and
an additional £100 surcharge for building and testing. Each bike comes with a 1-year
warranty, in addition to the customers statutory rights. Customers can optionally take out an
extra £50 warranty on the bike to upgrade the warranty to 3 years. A customer can order
more than one bike in the same transaction.
The system checks that the individual components required for an order are in stock,
calculates an estimated time for completion and the total price of the order. If the customer
agrees the cost and the timescale then the receptionist takes the customers personal details
(Name, Address, email) and enters them into the system. The system should validate that
the details are not blank, and ideally that the postcode and email address of a valid format. A
10% deposit must be paid by debit or credit card, and the receptionist records that the
payment has been successful on the system. If the payment request is rejected by the
customer’s bank, and the customer has no other valid method of payment by debit or credit
card then the order and is cancelled. If at a later time the customer cancels their order then
the customer loses their deposit (only the store manager can authorise a cancellation on the
system). If the transaction is approved by the customer’s bank then the system generates a
receipt detailing the order and remaining balance. The automated stock control system
generates orders for any components that are low in stock and sends them electronically to
the various suppliers (e.g. Shimano, Campagnolo, Rotor). The store manager can order
items via the system if required.
The completion time of the order is calculated based on the availability of stock, the
estimated delivery time for out of stock components and the anticipated build time. Standard
components take up to a week to arrive. Specialised components such as the Rotor Uno
hydraulic groupset can take up to 2 weeks to arrive. Building and testing each bike is
estimated to take half a day unless there is no mechanic available. Currently there are 3
mechanics available and they each work 5 days a week Monday to Friday. If there are not
sufficient mechanics available, an additional mechanics can be brought at one day’s notice.
A mechanic cannot start work on a bike until all the parts are available in the store. 
Bike parts that are delivered to the store are recorded onto the system by the stock
controller. At the start of each day, each mechanic logs onto the system and prints a
schedule detailing the orders that are to be built that day. At the end of their shift, each
mechanic records details of the bikes that have been completed. The receptionist checks for
completed orders at the start of each day and contacts customers to inform them that their
order is ready for collection.
The receptionist and the stock controller are able to generate reports detailing stock levels,
sales and outstanding orders that are awaiting delivery of components. The store manager is
able to carry out all of the functions that the receptionist can as well as being able to remove,
add and update components in the system. The system also records personal details about
each employee including their name, address, staff number, annual salary, email and phone
number. Only the store manager can add / remove and modify staff records.
