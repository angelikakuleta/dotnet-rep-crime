# **REP_CRIME.01**

Web app capable of quick reporting crimes for exemplary citizens.

## Business requirements

* Every user can report a crime (as a post request or from web client)
* Reported crime can be assigned to an police officer

## Requirements

* [Docker](https://docs.docker.com/get-docker/)

## How to run?

```
# Clone this repo locally
git clone https://github.com/angelikakuleta/motorola-3rd-exam.git
```

Run the following command in the solution directory

```
# build services
docker-compose build

# create and start containers
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up
```

Then, navigate to one of the services

* Crime Report Web: [http://localhost:8000](http://localhost:8000)
* Crime API: [http://localhost:8001](http://localhost:8001)
* Police API: [http://localhost:8002](http://localhost:8002)

If you want to use functionality of sending email notification, run the following command in the REP_CRIME01.CrimeFeedback project directory

```
# enable secret storage
dotnet user-secrets init

# set secrets
dotnet user-secrets set "SMTPSettings:MailFrom" "<EMAIL_ADDRESS>"
dotnet user-secrets set "SMTPSettings:Host" "<SMTP_HOST>"
dotnet user-secrets set "SMTPSettings:Port" "<SMTP_PORT>"
dotnet user-secrets set "SMTPSettings:UserName" "<USERNAME_TO_YOUR_EMAIL_ACCOUNT>"
dotnet user-secrets set "SMTPSettings:Password" "<PASSWORD_TO_YOUR_EMAIL_ACCOUNT>"
```