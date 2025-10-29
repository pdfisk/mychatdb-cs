import json
import requests
from typing import Any, Dict, Optional


class LmClient:
    """
    A lightweight client for communicating with LLM Studio via HTTP.
    Compatible with structured JSON input/output.
    """

    def __init__(
        self,
        base_url: str = "http://localhost:1234/v1/chat/completions",
        model: str = "default",
    ):
        self.base_url = base_url
        self.model = model

    def get_models(self) -> Optional[Dict[str, Any]]:
        """
        Retrieves the list of available models from the LLM Studio endpoint.
        """
        try:
            response = requests.get(
                self.base_url.replace("/chat/completions", "/models")
            )
            response.raise_for_status()
            return response.json()
        except requests.RequestException as e:
            print(f"[Error] {e}")
            return None

    def send_message(
        self, structured_input: Dict[str, Any]
    ) -> Optional[Dict[str, Any]]:
        """
        Sends structured input data to the LLM Studio endpoint and returns the structured response.
        structured_input should be a dictionary (e.g. {"task": "summarize", "text": "..."}).
        """
        try:
            # Convert structured data to a text message for the LLM
            user_content = json.dumps(structured_input, ensure_ascii=False, indent=2)

            payload = {
                "model": self.model,
                "messages": [
                    {
                        "role": "system",
                        "content": "You are a structured data assistant. Reply only in valid JSON.",
                    },
                    {"role": "user", "content": user_content},
                ],
            }

            headers = {"Content-Type": "application/json"}
            response = requests.post(
                self.base_url, headers=headers, json=payload, timeout=60
            )
            response.raise_for_status()

            data = response.json()

            # Parse JSON response if model outputs structured data
            content = (
                data.get("choices", [{}])[0].get("message", {}).get("content", "{}")
            )
            return json.loads(content)

        except (requests.RequestException, ValueError, json.JSONDecodeError) as e:
            print(f"[Error] {e}")
            return None


if __name__ == "__main__":
    # Example structured data task
    client = LLMStudioClient()

    input_data = {
        "task": "classify_review",
        "text": "The product quality was excellent but shipping was slow.",
        "labels": ["positive", "neutral", "negative"],
    }

    print("Sending structured data to LLM Studio...")
    response = client.send_message(input_data)

    print("\nStructured Response:")
    print(json.dumps(response, indent=2, ensure_ascii=False))
