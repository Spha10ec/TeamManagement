/// <reference path="../jquery-2.1.3.min.js" />
/// <reference path="../knockout-3.2.0.js" />


(function () {
    var viewModel = function () {
        var self = this;

        var IsUpdatable = false;

        self.Id = ko.observable(0);
        self.FirstName = ko.observable("");
        self.LastName = ko.observable("");
        self.DateOfBirth = ko.observable("");
        self.Weight = ko.observable("");
        self.Height = ko.observable("");
        self.Notes = ko.observable("");


        var PersonInfo = {
            Id: self.Id,
            FirstName: self.FirstName,
            LastName: self.LastName,
            DateOfBirth: self.DateOfBirth,
            Weight: self.Weight,
            Height: self.Height,
            Notes: self.Notes
        };

        self.Persons = ko.observable([]);

        self.Message = ko.observable("");

        self.Occupations = ko.observableArray(["Employeed", "Self-Employeed", "Doctor", "Teacher", "Other"]);
        self.SelectedOccupation = ko.observable();

        self.SelectedOccupation.subscribe(function (text) {
            self.Occupation(text);
        });


        self.States = ko.observableArray(["Jammu and Kashmir", "Delhi", "Himachal Pradesh",
        "Uttarakhand", "Punjab", "Hariyana", "Uttar Pradesh", "Rajasthan",
        "Madhya Pradesh", "Odissa", "Assam", "Arunchal Pradesh", "Manipur",
        "Mizoram", "Tripura", "Manupur", "Nagaland", "Jharkhand", "Bihar", "Sikkim",
        "Maharashtra", "Gujarat", "GOA", "Karnatak", "Telangana", "Simandhra",
        "Tamilnadu", "Kerla", "Andaman and Nikobar"]);

        self.SelectedState = ko.observable();

        self.SelectedState.subscribe(function (text) {
            self.State(text);
        });




        loadInformation();

        function loadInformation() {

            $.ajax({
                url: "/Home/GetPersonInformations",
                type: "GET"
            }).success(function (data) {
                self.Persons(data);
            }).error(function (err) {
                self.Message("Error! " + err.status);
            });
        }

        self.getSelected = function (per) {
            self.Id(per.Id);
            self.FirstName(per.FirstName);
            self.LastName(per.LastName);
            self.Address(per.DateOfBirth);
            self.City(per.Weight);
            self.State(per.Height);
            self.PhoneNo(per.Notes);
            IsUpdatable = true;
            $("#modalbox").modal("show");
        }

        self.save = function () {
            if (!IsUpdatable) {

                $.ajax({
                    url: "/Home/GetPersonInformations",
                    type: "POST",
                    data: PersonInfo,
                    datatype: "json",
                    contenttype: "application/json;utf-8"
                }).done(function (resp) {
                    self.Id(resp.Id);
                    $("#modalbox").modal("hide");
                    loadInformation();
                }).error(function (err) {
                    self.Message("Error! " + err.status);
                });
            } else {
                $.ajax({
                    url: "/Home/GetPersonInformations" + self.Id(),
                    type: "PUT",
                    data: PersonInfo,
                    datatype: "json",
                    contenttype: "application/json;utf-8"
                }).done(function (resp) {
                    $("#modalbox").modal("hide");
                    loadInformation();
                    IsUpdatable = false;
                }).error(function (err) {
                    self.Message("Error! " + err.status);
                    IsUpdatable = false;
                });

            }
        }

        self.delete = function (per) {
            $.ajax({
                url: "/Home/GetPersonInformations" + per.Id,
                type: "DELETE",
            }).done(function (resp) {
                loadInformation();
            }).error(function (err) {
                self.Message("Error! " + err.status);
            });
        }

    };
    ko.applyBindings(new viewModel());
})();