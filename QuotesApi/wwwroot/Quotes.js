async function getQuote() {
  const response = await fetch(
    "https://randomquotesapi-4.onrender.com/api/Quotes"
  );
  const data = await response.json();
  document.getElementById("quote").textContent = data.quote;
}

document.getElementById("btn").addEventListener("click", getQuote);
