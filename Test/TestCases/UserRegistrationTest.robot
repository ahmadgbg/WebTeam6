*** Settings ***
Documentation  This is a test suite that tests the Webteam6 website
Library  SeleniumLibrary
Test Setup  Begin Test
Test Teardown  End Test

*** Variables ***
${BROWSERS}                             chrome
${FIRSTNAME}                            Erik
${LASTNAME}                             Eriksson
${EMAIL}                                erik.eriksson@hotmail.com
${PASSWORD}                             User456!

*** Keywords ***
Begin Test
        Open Browser                    about:blank  ${BROWSERS}    options=add_argument("--ignore-certificate-errors")
        Maximize Browser Window
        Load Page
        Verify Page Loaded

Load Page
        Go To                           https://localhost:5001
        Sleep                           5s
Verify Page Loaded
        Wait Until Page Contains        RemoteTool

End Test
        Close Browser

*** Test Cases ***
Register user with invalid email account
    [Documentation]                     Test for rgister user with invalid email account
    [Tags]                              Register user with invalid email account_Test
    Set Selenium Implicit Wait          10 seconds
    Wait Until Element Is Visible       id:landingRegisterButton
    Click Element                       id:landingRegisterButton
    Wait Until Page Contains            Register
    Input Text                         id:registerEmail    erik.erikssonhotmail.com
    Input Text                          id:registerFirstname    ${FIRSTNAME}
    Input Text                          id:registerLastname         ${LASTNAME}
    Input Text                          id:registerPassword    ${PASSWORD}
    Input Text                          id:registercomPassword       ${PASSWORD}
    Click Element                       id:registerSubmit
    Wait Until Page Contains            error messege, enter the correct email accont

*** Test Cases ***
Register user with invalid first name
    [Documentation]                     Test for register user with invalid first name
    [Tags]                              Register user with invalid first name_test
    Set Selenium Implicit Wait          10 seconds
    Wait Until Element Is Visible       id:landingRegisterButton
    Click Element                       id:landingRegisterButton
    Wait Until Page Contains            Register
    Input Text                         id:registerEmail     ${EMAIL}
    Input Text                          id:registerFirstname
    Input Text                          id:registerLastname         ${LASTNAME}
    Input Text                          id:registerPassword    ${PASSWORD}
    Input Text                          id:registercomPassword       ${PASSWORD}
    Click Element                       id:registerSubmit
    Wait Until Page Contains            error messege, fill in all fields

Register user with invalid last name
    [Documentation]                     Test for register user with invalid last name
    [Tags]                              Register user with invalid last name_test
    Set Selenium Implicit Wait          10 seconds
    Wait Until Element Is Visible       id:landingRegisterButton
    Click Element                       id:landingRegisterButton
    Wait Until Page Contains            Register
    Input Text                         id:registerEmail    ${EMAIL}
    Input Text                          id:registerFirstname    ${FIRSTNAME}
    Input Text                          id:registerLastname
    Input Text                          id:registerPassword    ${PASSWORD}
    Input Text                          id:registercomPassword       ${PASSWORD}
    Click Element                       id:registerSubmit
    Wait Until Page Contains            error messege, fill in all fields

*** Test Cases ***
Register user with invalid password
    [Documentation]                     Test for register user with invalid password
    [Tags]                              Register user with invalid password_test
    Set Selenium Implicit Wait          10 seconds
    Wait Until Element Is Visible       id:landingRegisterButton
    Click Element                       id:landingRegisterButton
    Wait Until Page Contains            Register
     Input Text                         id:registerEmail     ${EMAIL}
    Input Text                          id:registerFirstname    ${FIRSTNAME}
    Input Text                          id:registerLastname         ${LASTNAME}
    Input Text                          id:registerPassword
    Input Text                          id:registercomPassword       ${PASSWORD}
    Click Element                       id:registerSubmit
    Wait Until Page Contains            error messege, fill in all fields

*** Test Cases ***
Register user with invalid comfirm password
    [Documentation]                     Test for register user with invalid comfirm password
    [Tags]                              Register user with invalid first name_test
    Set Selenium Implicit Wait          10 seconds
    Wait Until Element Is Visible       id:landingRegisterButton
    Click Element                       id:landingRegisterButton
    Wait Until Page Contains            Register
     Input Text                         id:registerEmail     ${EMAIL}
    Input Text                          id:registerFirstname       ${FIRSTNAME}
    Input Text                          id:registerLastname         ${LASTNAME}
    Input Text                          id:registerPassword    ${PASSWORD}
    Input Text                          id:registercomPassword       User456
    Click Element                       id:registerSubmit
    Wait Until Page Contains            error messege, enter the correct password

*** Test Cases ***
Register and verify user
    [Documentation]                     Test for register and verify user account
    [Tags]                              register and verify user_test
    Set Selenium Implicit Wait          10 seconds
    Wait Until Element Is Visible       id:landingRegisterButton
    Click Element                       id:landingRegisterButton
    Wait Until Page Contains            Register
    Input Text                          id:registerEmail    ${EMAIL}
    Input Text                          id:registerFirstname    ${FIRSTNAME}
    Input Text                          id:registerLastname         ${LASTNAME}
    Input Text                          id:registerPassword    ${PASSWORD}
    Input Text                          id:registercomPassword       ${PASSWORD}
    Click Element                       id:registerSubmit
    Wait Until Page Contains            Registration Completed

*** Test Cases ***
Delete user
    [Documentation]                     Test for register, verify and delete user account
    [Tags]                              deleteUser_test
    Set Selenium Implicit Wait          10 seconds
    Wait Until Page Contains            Welcome to RemoteTool
    Click Element                       id:landingLoginButton
    Wait Until Page Contains            Login
    Input Text                          id:loginEmail     ${EMAIL}
    Input Text                          id:loginPassword     ${PASSWORD}
    Click Element                       id:loginSubmit
    Wait Until Page Contains			Welcome, ${FIRSTNAME}
    Click Element                       id:accountSettings
    Wait Until Page Contains            Account settings
    Click Element                       id:deleteAccount
    Wait Until Page Contains            account is deleted





