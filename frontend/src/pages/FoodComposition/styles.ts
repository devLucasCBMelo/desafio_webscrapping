import styled from "styled-components";

export const FoodCompositionContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  min-height: 100vh;
`

export const FoodCompositionMain = styled.main`
  display: flex;
  flex-direction: column;
  align-items: center;
  flex: 1;
  margin-bottom: 20px;

  input {
    width: 200px;
  }
`

export const SearchBarContainer = styled.div`
  display: flex;
  flex-direction: row;
  margin-bottom: 30px;

  input {
    border-radius: 5px;
    border: solid black 1px;
    min-width: 250px;
    padding-left: 5px;
  }

  button {
    margin-left: 2px;
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
`

export const FoodCardList = styled.div`
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  max-width: 1000px;
`

export const LoadMoreCardsButton = styled.button`
  margin-top: 20px;
  margin-left: 2px;
  background-color: #ee8003;
  color: white;
  border: none;
  padding: 8px 12px;
  font-size: 14px;
  font-weight: bold;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease-in-out;

  &:hover {
    background-color: #ee2f03;
  }
`