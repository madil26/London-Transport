import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search-flights',
  templateUrl: './search-flights.component.html',
  styleUrls: ['./search-flights.component.css']
})
export class SearchFlightsComponent implements OnInit {

  searchResults: FlightRm[] = [
    {
      airline: 'Pak Air',
      remainingSeats: 7,
      departure: { time: Date.now().toString(), place:"Islamabad, Pakistan" },
      arrival: { time: Date.now().toString(), place: "New York" },
      price: '500',
    },
    {
      airline: 'Qatar Airlines',
      remainingSeats: 45,
      departure: { time: Date.now().toString(), place: "Dubai, UAE" },
      arrival: { time: Date.now().toString(), place: "London, England" },
      price: '554',
    },
    {
      airline: 'Etihad Airways',
      remainingSeats: 5,
      departure: { time: Date.now().toString(), place: "Los Angeles" },
      arrival: { time: Date.now().toString(), place: "Berlin" },
      price: '964',
    },
  ]

  constructor() { }

  ngOnInit(): void { }
}

export interface FlightRm {
  airline: string;
  arrival: TimePlaceRm;
  departure: TimePlaceRm;
  price: string;
  remainingSeats: number;
}

export interface TimePlaceRm {
  place: string;
  time: string;
}
