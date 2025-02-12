import styled from "styled-components";

export const LoginContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  min-height: 100vh;
`

export const LoginMain = styled.main`
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;

  @media (max-width: 500px) {
    h1 {
      font-size: 18px;
    }
  }
`

export const LoginForm = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  background-color: #DAC8B3;
  min-height: 240px;
  align-items: center;
  justify-content: center;
  border-radius: 17px;
  width: 500px;

  label {
    margin-bottom: 10px;
    font-size: 18px;

    input {
      margin-left: 5px;
      border-radius: 5px;
      border: none;
      height: 22px;
      font-size: 13px;
      min-width: 250px;
      padding-left: 7px;
    }
  }

  button {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 8px 12px;
    font-size: 14px;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease-in-out;

    &:hover {
      background-color: #0056b3;
    }
  }

  @media (max-width: 500px) {
    width: 350px;
    min-height: 200px;

    label {
      font-size: 15px;

      input {
        min-width: 180px;
      }
    }

    button {
      margin-top: 20px;
    }
  }
`