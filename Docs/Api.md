# Ventris Dual Reverb API

## POST /VentrisDualReverb

This endpoint updates the settings for the Ventris Dual Reverb effect.

### Request

Content-Type: `application/json`

#### Body

```json
{
  "preset": "Hall",
  "mix": 75,
  "time": 60,
  "preDelay": 20,
  "outputLevel": -3
}
```

- `preset`: The reverb preset to use. Options include "Hall", "Room", "Plate", etc.
- `mix`: The mix level of the effect (0-100).
- `time`: The decay time of the reverb (0-100).
- `preDelay`: The pre-delay time in milliseconds (0-250).
- `outputLevel`: The output level in dB (-20 to +20).

### Response

#### Success

Status Code: `200 OK`

```json
{
  "message": "Settings updated successfully.",
  "status": "success"
}
```

#### Error
Status Code: `400 Bad Request`

```json
{
  "error": "Invalid request data.",
  "status": "error"
}
```